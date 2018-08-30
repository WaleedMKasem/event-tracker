declare module server {
	interface Place {
		country: server.Country;
		state: {
			stateId: number;
			name: string;
		};
		city: server.City;
		other: string;
	}
}
