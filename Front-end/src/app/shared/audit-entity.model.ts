import { BaseEntity } from "./base-entity.model";
import { Data } from "@angular/router/src/config";

export class AuditEntity extends BaseEntity {
    createdBy?: number;
    createdOn: Date = new Date();
    modifiedBy?: number;
    modifiedOn?: Date;
    isDeleted: boolean = false;
    deletedBy?: number;
    deletedOn?: Date;

}