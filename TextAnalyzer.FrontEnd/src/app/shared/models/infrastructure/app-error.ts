export class AppError {
    constructor(public originalError?: any) {
        console.log("AppError");
    }
}