declare module server {
	interface Seaport extends BaseEntity {
		/** public int PortId { get; set; } */
		name: string;
		type: server.Lookup;
		place: server.Place;
		location: server.Location;
		loCode: string;
	}
}
