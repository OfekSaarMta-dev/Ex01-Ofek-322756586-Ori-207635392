using System.Linq;

namespace Ex01_01
{
    class BinaryNumber
    {
        private string m_BinaryString;
        private int m_DecimalValue;
        private int m_LongestOnesSequence;
        private int m_NumberOfChangesBetween0And1;
        private int m_OnesCount;


        public BinaryNumber() // empty ctor
        {
            m_BinaryString = "";
            m_DecimalValue = 0;
            m_LongestOnesSequence = 0;
            m_NumberOfChangesBetween0And1 = 0;
            m_OnesCount = 0;
        }

        public static bool IsBinaryNameValid(string i_inputString)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(i_inputString) && i_inputString.Length >= 7)
            {
                isValid = false;
            }

            foreach (char charachter in i_inputString)
            {
                if (charachter != '0' && charachter != '1') 
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        public void Update(string i_binaryString) // Function updates members of existing Binary Number
        {
            m_BinaryString = i_binaryString; // updating m_BinaryString
            binaryNumberStringToDecimalValue(); // updating m_DecimalValue 
            longestOnesSequenceAndOnesCounter(); // updating m_LongestOnesSequence and updating m_OnesCount
            numberOfChangesBetween0And1(); // updating m_NumberOfChangesBetween0And1

        }

        private void binaryNumberStringToDecimalValue()
        {
            int binaryInt;
            bool success = int.TryParse(m_BinaryString, out binaryInt); //we already know the string is valid for it to "become" int because we checked the validity already
            m_DecimalValue = convertBinaryToDecimal(binaryInt);
        }

        private int convertBinaryToDecimal(int i_binaryInt)
        {
            int decimalValue = 0;       
            int lastDigit;
            int baseValue = 1;
            while (i_binaryInt > 0)
            {
                lastDigit = i_binaryInt % 10;
                i_binaryInt /= 10;
                decimalValue += lastDigit * baseValue;
                baseValue *= 2;
            }
            return decimalValue;
        }

        private void longestOnesSequenceAndOnesCounter()
        {
            int onesCounter = 0;
            int onesSequence = 0;
            int maxOnesSequence = 0;

            foreach(char charachter in m_BinaryString)
            {
                if(charachter == '1')
                {
                    onesCounter++;
                    onesSequence++;
                    if(onesSequence > maxOnesSequence)
                    {
                        maxOnesSequence = onesSequence;
                    }
                }
                else // if charachter equals '0' stop sequence
                {
                    onesCounter = 0;
                }
            }

            m_LongestOnesSequence = maxOnesSequence;
            m_OnesCount = onesSequence;
        }

        private void numberOfChangesBetween0And1() 
        {
            int changesCounter = 0;

            for(int i = 1; i < m_BinaryString.Length; i++)
            {
                if (m_BinaryString[i] != m_BinaryString[i-1]) //  // If current character is different from the previous one
                {
                    changesCounter++;
                }
            }

            m_NumberOfChangesBetween0And1 = changesCounter;
        }
   
        public string GetBinaryString()
        {
            return m_BinaryString;
        }

        public int GetDecimalValue()
        {
            return m_DecimalValue;
        }

        public int GetLongestOnesSequence()
        {
            return m_LongestOnesSequence;
        }

        public int GetNumberOfChangesBetween0And1()
        {
            return m_NumberOfChangesBetween0And1;
        }

        public int GetOnesCount()
        {
            return m_OnesCount;
        }
    }

}





