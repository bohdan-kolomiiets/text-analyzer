import { BaseObject } from './../../shared/models/base-object';
export class Data extends BaseObject {
    dataValue: string;

    constructor(id: number = 0, title: string = "", description: string = "", dataValue: string = "") {
        super(id, title, description);
        this.dataValue = dataValue;

        this.test_init();
    }

    test_init(){
        this.title = "Text title";
        this.description = "This text is for testing";
        this.dataValue = 
        `Bootstrap is the most popular HTML, CSS, and JavaScript framework for web front-end
         development. It’s great for developing responsive, mobile-first web sites.
          The Bootstrap website is available at http://getbootstrap.com/. 
          The Bootstrap framework can be used together with modern JavaScript web & mobile frameworks like Angular.
           In the following you’ll learn how to use the Bootstrap framework in your Angular project. 
           Furthermore we’ll take a look at the Ng-Bootstrap project which delivers Angular Bootstrap 
           components which can be used out of the box.`;
    }
}