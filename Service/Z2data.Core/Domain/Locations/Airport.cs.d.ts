declare module server {
	interface Airport extends BaseEntity {
		/** public int AirportId { get; set; } */
		name: string;
		type: server.Lookup;
		place: {
			country: server.Country;
			state: {
				stateId: number;
				name: string;
			};
			city: server.City;
			other: string;
		};
		iataCode: string;
		code: string;
		location: server.Location;
		elevation?: number;
	}
}
