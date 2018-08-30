import { BaseEntity } from '../shared/BaseEntity';
import { LocationType } from '../shared/enums/location-Type';
export interface Location {
		type: LocationType;
		coordinates: number[];
}
