declare module server {
	interface Park extends BaseEntity {
		/** public int ParkId { get; set; } */
		name: string;
		address: string;
		place: {
			country: server.Country;
			state: {
				stateId: number;
				name: string;
			};
			city: server.City;
			other: string;
		};
		location: server.Location;
		rating: server.Rating;
		establishedYear?: number;
		area?: number;
		companies: server.Company[];
		industries: server.Lookup[];
	}
}
