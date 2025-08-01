export type NotificationWithAction = {
    title: string;
    description: string;
    type: "success" | "error" | "info" | "warning"
    actionLabel: string;
    actionAsync(): Promise<void>;
}