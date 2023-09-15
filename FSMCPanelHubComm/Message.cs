namespace FSMCPanelHubComm
{
    /// <summary>
    /// POCO-class for a message-object which is serialized and to be send between the PanelHub and a MicroController.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// The ident-string of the message-sender.
        /// </summary>
        public string SenderIdent { get; set; }
        /// <summary>
        /// The ident-string of the message-recipient.
        /// </summary>
        public string RecipientIdent { get; set; }
        /// <summary>
        /// The Panel-Ident-string.
        /// </summary>
        public string PanelIdent { get; set; }
        /// <summary>
        /// The Panel-Type-Ident-string. This ident is used for identifying the category the panel belongs to.
        /// </summary>
        public string PanelTypeIdent { get; set; }
        /// <summary>
        /// The name of the control this message references to.
        /// </summary>
        public string ControlName { get; set; }
        /// <summary>
        /// The payload of the message.
        /// </summary>
        public string Payload { get; set; }
    }
}