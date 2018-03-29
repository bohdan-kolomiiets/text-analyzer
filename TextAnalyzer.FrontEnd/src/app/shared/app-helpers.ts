import { DatePipe } from '@angular/common';

export class AppHelpers {

    public static containsOnlySpaces(str: string): boolean {
        if (!str.replace(' ', '').length)
            return true;
        return false;
    }

    public static toNumberArray(str: string): number[] {
        return str.toString().split(',').map(el => +el);
    } 

    public static toStringFromArray(array: number[]): string {
        let res = "";
        array.forEach((el, index) => {
            if (index < array.length - 1)
                res += `${el},`;
            else
                res += `${el}`;
        });
        // console.log(array, res);
        return res;
    }

    public static toQueryString(obj) {
        if (obj == null)
            return '';
        var parts = [];
        for (var property in obj) {
            let value: any;
            if (obj[property] instanceof Array)
                value = AppHelpers.toStringFromArray(obj[property]);
            else
                value = obj[property];

            if (value != null && value != undefined) {
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
            }
        }
        var queryString = parts.join('&');
        // console.log("query, ", queryString);
        return `?{queryString}`;
    }


    public static getFormattedDate(date: Date, format: string = "y-MM-dd", locale: string = "en"): string {
        let dp = new DatePipe("en");
        let formattedDate = dp.transform(date, format);
        console.log("formatted date:", formattedDate);
        return formattedDate;
    }

    public static addMinutes(dateInMillis, minutes) {
        return dateInMillis + minutes * 60000;
    }

    public static addDays(dateInMillis, days) {
        return dateInMillis + days * 1000 * 60 * 60 * 24;
    }
}