import { BaseEntity } from '../shared/baseEntity';
import { Company } from '../locations/company';
import { Country } from '../lookups/country';
import { City } from '../lookups/city';
import { Lookup } from '../lookups/lookup';
import { Rating } from '../shared/enums/rating';

export interface Park extends BaseEntity {
		/** public int ParkId { get; set; } */
		name: string;
		address: string;
		place: {
			country: Country;
			state: {
				stateId: number;
				name: string;
			};
			city: City;
			other: string;
		};
		location: Location;
		rating: Rating;
		establishedYear?: number;
		area?: number;
		companies: Company[];
		industries: Lookup[];
}
