import { BaseEntity } from '../../shared/BaseEntity';
export interface Attachment extends BaseEntity {
		name: string;
		extension: string;
}
