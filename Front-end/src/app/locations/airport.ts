import { BaseEntity } from '../shared/baseEntity';
import { Lookup } from '../lookups/lookup';
import { Country } from '../lookups/country';
import { City } from '../lookups/city';

export interface Airport extends BaseEntity {
		/** public int AirportId { get; set; } */
		name: string;
		type: Lookup;
		place: {
			country: Country;
			state: {
				stateId: number;
				name: string;
			};
			city: City;
			other: string;
		};
		iataCode: string;
		code: string;
		location: Location;
		elevation?: number;
}
