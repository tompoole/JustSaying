using System.Configuration;

namespace JustSaying.AwsTools.QueueCreation
{
    public class SqsBasicConfiguration
    {
        public int MessageRetentionSeconds { get; set; }
        public int ErrorQueueRetentionPeriodSeconds { get; set; }
        public int VisibilityTimeoutSeconds { get; set; }
        public int RetryCountBeforeSendingToErrorQueue { get; set; }
        public bool ErrorQueueOptOut { get; set; }

        public SqsBasicConfiguration()
        {
            MessageRetentionSeconds = JustSayingConstants.DEFAULT_RETENTION_PERIOD;
            VisibilityTimeoutSeconds = JustSayingConstants.DEFAULT_VISIBILITY_TIMEOUT;
            RetryCountBeforeSendingToErrorQueue = JustSayingConstants.DEFAULT_HANDLER_RETRY_COUNT;
        }

        public virtual void Validate()
        {
            if (MessageRetentionSeconds < JustSayingConstants.MINIMUM_RETENTION_PERIOD || MessageRetentionSeconds > JustSayingConstants.MAXIMUM_RETENTION_PERIOD)
                throw new ConfigurationErrorsException(string.Format("Invalid configuration. MessageRetentionSeconds must be between {0} and {1}.", JustSayingConstants.MINIMUM_RETENTION_PERIOD, JustSayingConstants.MAXIMUM_RETENTION_PERIOD));
        }
    }
}