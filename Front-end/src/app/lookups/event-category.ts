import { BaseEntity } from '../shared/baseEntity';
import { Lookup } from '../lookups/lookup';
export interface EventCategory extends BaseEntity {
		name: string;
		eventTypes: Lookup[];
}
