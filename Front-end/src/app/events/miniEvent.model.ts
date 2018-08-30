import { BaseEntity } from "../shared/base-entity.model";

export interface MiniEvent extends BaseEntity {
    code: string;
    category: string;
    type: string;
    startDate?: Date;
    lastUpdated?: Date;
    title: string;
    country: string;
    state: string;
    city: string;
    severity: string;
    status: string;

}
