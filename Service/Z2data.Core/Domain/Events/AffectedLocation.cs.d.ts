declare module server {
	interface AffectedLocation extends BaseEntity {
		locationId: any;
		name: string;
		location: server.Location;
		type: server.AffectedLocationType;
		locationType: string;
		iata: string;
		locode: string;
		disasterTypes: server.Lookup[];
		distance: number;
		associatedDistance?: number;
		status: server.Effect;
		isConfirmed: boolean;
	}
}
