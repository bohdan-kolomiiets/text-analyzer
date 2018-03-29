export class Query {
        // isRealQuery: boolean;
        sortBy: string = '';
        isSortAscending: boolean = true;
        page: number = 1;
        newPage: number;
        pageSize: number = 10;

        constructor() {
                this.newPage = this.page;
        }
}