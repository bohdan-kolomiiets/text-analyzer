import { TextDataService } from './../../services/text-data.service';
import { Data } from './../../models/data';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { QueryResult } from '../../../shared/models/query-result';
import { AppError } from '../../../shared/models/infrastructure/app-error';
import { NotFoundAppError } from '../../../shared/models/infrastructure/not-found-error';

@Component({
  selector: 'app-data-form',
  templateUrl: './data-form.component.html',
  styleUrls: ['./data-form.component.css']
})
export class DataFormComponent implements OnInit {

  @Input() form: FormGroup;
  @Input() data: Data = new Data();
  
  isSubmitting: boolean = false;
  isSuccessful?: boolean = null;
  submissionMessage: string = "";

  static init(fb: FormBuilder, data: Data = new Data()) {
    let formGroup = fb.group({
      id: data.id,
      title: data.title,
      description: data.description,
      dataValue: data.dataValue
    });
    return formGroup;
  }

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private textDataService: TextDataService) {

      this.route.params.subscribe(p => {
        let tagId = +p["id"];
        if (tagId)
          this.data.id = tagId;
      });

     }

  ngOnInit() {

    if(this.data.id) {
      this.textDataService.get(this.data.id, null).subscribe(
        (tag: Data) => {
          this.data = tag;
          console.log("text_data", this.data);
          this.form = DataFormComponent.init(this.fb, this.data);
        },
        (error: AppError) => {
          if (error instanceof NotFoundAppError) {
            this.router.navigate(['/not-found']);
          }
        }
      );
    } else {
      this.form = DataFormComponent.init(this.fb);
    }

  }

  submit() {
    this.isSubmitting = true;

    if(!this.data.id) {
      console.log("create data text");
      this.textDataService.create(this.data)
      .finally(() => {
        this.isSubmitting = false;
        setTimeout(() => {
          this.submissionMessage = null;
          if (this.isSuccessful)
            this.router.navigate([`/texts/${this.data.id}/edit`]);
        }, 1000);
      })
      .subscribe(
        (dataId: number) => {
          this.data.id = dataId;
          console.log("after submission", this.data);
          this.isSuccessful = true;
          this.submissionMessage = "Text data was successfully added.";
        },
        (error: AppError) => {
          this.isSuccessful = false;
          this.submissionMessage = "An error occured while text data was creating.";
        }
      );
    } else {
      this.textDataService.update(this.data)
      .finally(() => {
        // console.log("complete");
        this.isSubmitting = false;
        setTimeout(() => { this.submissionMessage = null; this.isSuccessful = null; }, 2000);
      })
      .subscribe(
      (dataId: number) => {
        // console.log("after submission", res);
        this.isSuccessful = true;
        this.submissionMessage = "Text data was successfully updated.";
      },
      (error: AppError) => {
        this.isSuccessful = false;
        this.submissionMessage = "An error occured while text data was updating.";
      });
    }
  }

}
