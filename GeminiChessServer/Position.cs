namespace GeminiChessServer
{
    class Position
    {
        private string positionY;
        private string positionX;
        private int locationX;
        private int locationY;

        public Position(string positionX, string positionY,int locationX , int locationY) {
            this.positionX = positionX;
            this.positionY = positionY;
            this.locationX = locationX;
            this.locationY = locationY;

        }

        public string GetPositionX() {
            return positionX;
        }

        public string GetPositionY()
        {
            return positionY;
        }
        public int GetLocationX()
        {
            return locationX;
        }

        public int  GetLocationY()
        {
            return locationY;
        }
    }
}
