
import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { ImportType } from '../shared/enums/importtype';
import { FileService } from '../shared/file.service';
@Component({
    selector: 'app-importer',
    templateUrl: './importer.component.html',
    styleUrls: ['./importer.component.css']
})
export class ImporterComponent implements OnInit {

    type: number = -1;
    typeName: string = "None";
    files: any[];
    successNote: string;
    errorNote: string;
    isLoadingData: boolean = false;
    constructor(protected _fileService: FileService) { }

    ngOnInit() {
    }

    fileChangeEvent(fileInput: any) {
        this.files = <Array<File>>fileInput.target.files;
    }
    onImportClick() {
        this.successNote = "";
        this.errorNote = "";
        if (this.files == null || this.files.length == 0) {
            this.errorNote = "Please select at least 1 file to upload!";
        }
        else if (this.files != null && this.type == -1) {
            this.errorNote = "Please select file type!";
        }
        else {
            let formData: FormData = new FormData();
            for (let i = 0; i < this.files.length; i++) {
                formData.append('uploadedFiles', this.files[i], this.files[i].name);
            }
                
            this.isLoadingData = true;
            this._fileService.importExcel(this.type, formData)
            .subscribe(res => {
                this.successNote = res + " Records Affected.";
                this.isLoadingData = false;
            });
        }
    }
    onSelectType(type) {
        this.type = type;
        this.typeName = ImportType[type];
    }
}
