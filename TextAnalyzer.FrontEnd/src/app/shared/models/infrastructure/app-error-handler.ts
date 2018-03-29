import { ErrorHandler } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {
    handleError() {
        alert('An unexpected error occured.');
        console.log('An unexpected error occured.');
    }
}