declare module server {
	interface EventCategory extends BaseEntity {
		name: string;
		eventTypes: server.Lookup[];
	}
}
