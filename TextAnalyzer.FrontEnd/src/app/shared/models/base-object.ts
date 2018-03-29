export class BaseObject {
    id: number = 0;
    title: string = "";
    description: string = "";
    createdAt: Date = null;
    constructor(id: number = 0, title: string = "", description: string = "") {
        this.id = id;
        this.title = title;
        this.description = description;
    }
}