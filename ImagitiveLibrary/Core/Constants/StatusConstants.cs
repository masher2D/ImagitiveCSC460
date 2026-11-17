namespace ImagitiveLibrary.Core.Constants
{
    public static class AccountStatuses
    {
        public const string Active = "Active";
        public const string Restricted = "Restricted";
        public const string Banned = "Banned";
        public const string Deactivated = "Deactivated";
        public const string Warned = "Warned";
    }

    public static class ModerationStatuses
    {
        public const string Unresolved = "Unresolved";
        public const string Resolved = "Resolved";
        public const string UnderReview = "UnderReview";
        public const string Discarded = "Discarded";
    }

    public static class PromotionResponseChoices
    {
        public const string Approve = "Approve";
        public const string Deny = "Deny";
    }

    public static class ReportResponseChoices
    {
        public const string Ban = "Ban the reported user";
        public const string Warn = "Warn the reported user";
        public const string Dismiss = "Dismiss the report";

        public const string Restrict = "Restrict the reported user";
    }
}
