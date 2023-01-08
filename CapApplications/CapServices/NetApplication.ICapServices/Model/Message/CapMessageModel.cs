using DotNetCore.CAP.Messages;

namespace NetApplication.ICapServices.Model.Message
{
    public class CapMessageModel
    {
        public MessageType MsgType { get; set; }

        public DotNetCore.CAP.Messages.Message Message { get; set; }
    }
}
