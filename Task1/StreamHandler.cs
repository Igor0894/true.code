namespace Task1
{
    public class StreamHandler
    {
        Stream Stream { get; set; }
        int BufferSize { get; set; }
        char EndOfMessage { get; set; }
        public StreamHandler(Stream stream, int bufferSize, char endOfMessage)
        {
            this.Stream = stream;
            this.BufferSize = bufferSize;
            this.EndOfMessage = endOfMessage;
        }
        public byte[] ReadMessage()
#warning Повторное использование приведёт к утере данных при окончании чтения сообщения не в tempBuffer.Length - 1
        {
            List<byte> buffer = new List<byte>();
            byte[] tempBuffer = new byte[BufferSize];
            bool messageEnded = false;
            while (!messageEnded && Stream.Read(tempBuffer, 0, BufferSize) > 0)
            {
                foreach (byte b in tempBuffer)
                {
                    if (b != EndOfMessage) { buffer.Add(b); }
                    else { messageEnded = true; break; }
                }
            }
            return buffer.ToArray();
        }
    }
}