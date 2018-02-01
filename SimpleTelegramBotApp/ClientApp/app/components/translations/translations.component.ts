import { Component, OnInit } from '@angular/core';
import { FormControl } from "@angular/forms";
import { Translation } from '../../models/translation.model';
import { TranslationsService } from '../../service/translations.service';
import { ToastrService } from "ngx-toastr";

@Component({
    selector: 'app-translations',
    templateUrl: './translations.component.html',
    styleUrls: ['./translations.component.css']
})
export class TranslationsComponent implements OnInit {

    translations: Translation[];
    translation: Translation;
    tableMode: boolean = true;
    submitted: boolean = false;

    constructor(private traslationsService: TranslationsService,
        private toastr: ToastrService) {

    }

    ngOnInit() {
        this.traslationsService.getTranslations().subscribe((data: Translation[]) => {
            this.translations = data;
        });
    }

    load() {
        this.traslationsService.getTranslations().subscribe((data: Translation[]) => {
            this.translations = data;
        }, () => {
            this.showErrorToast('Loading translations error');
        });
    }

    save() {
        this.submitted = true;
        if (this.translation.id == null) {
            this.traslationsService.createTranslation(this.translation)
                .subscribe((data: Translation) => {
                    this.load();
                    this.toastr.success('Successfull created', 'Success');
                }, () => {
                    this.showErrorToast('Creating error');
                });
        } else {
            this.traslationsService.updateTranslation(this.translation)
                .finally(() => this.load())
                .subscribe(() => {
                    this.toastr.success('Successfull updated', 'Success');
                }, () => {
                    this.showErrorToast('Updating error');
                });
        }
        this.cancel();
    }

    editTranslation(t: Translation) {
        this.translation = t;
    }

    cancel() {
        this.translation = new Translation();
        this.tableMode = true;
        this.submitted = false;
    }

    delete(t: Translation) {
        this.traslationsService.deleteTranslation(t.id)
            .subscribe(() => {
                this.load();
                this.toastr.success('Successfull deleted', 'Success');
            }, () => {
                this.showErrorToast('Deleting error');
            });
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }

    showErrorToast(message: string) {
        const errToast = this.toastr.error(message, 'Error');
        if (errToast) {
            errToast.onTap.subscribe(() => {
                this.load();
            });
        }
    }
}