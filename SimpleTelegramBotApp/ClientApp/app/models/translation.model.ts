export class Translation {
    id: number;
    sourceText: string;
    translatedText: string;
    from: string;
    to: string;

    constructor() {
        this.from = "ru";
        this.to = "en";
    }
}