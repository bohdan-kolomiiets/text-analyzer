import { AppError } from './app-error';
export class NotFoundAppError extends AppError {
    constructor(public originalError?: any) {
        super(originalError);
        console.log("NotFoundAppError");
    }
}