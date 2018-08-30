declare module server {
	interface Attachment extends BaseEntity {
		name: string;
		extension: string;
	}
	interface MiniAttachment {
		id: string;
		name: string;
		extension: string;
	}
}
