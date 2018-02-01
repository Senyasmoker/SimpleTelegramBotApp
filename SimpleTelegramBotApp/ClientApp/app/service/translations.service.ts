import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Translation } from "../models/translation.model";
import 'rxjs/add/operator/finally';

@Injectable()
export class TranslationsService {
    private url = "/api/translations";

    constructor(private http: HttpClient) {
    }

    getTranslations() {
        return this.http.get(this.url);
    }

    createTranslation(translation: Translation) {
        return this.http.post(this.url, translation);
    }

    updateTranslation(translation: Translation) {
        return this.http.put(this.url + '/' + translation.id, translation);
    }

    deleteTranslation(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}