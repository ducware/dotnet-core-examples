namespace Ducware.Example;

public static class ConvertNumberToText
{
    public static string ConvertPhoneNumber(string phoneNumber) 
    {
        // Mảng chuỗi tương ứng với từng chữ số
        string[] numberText = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        
        // Chuỗi kết quả
        string result = "";
        
        // Duyệt qua từng chữ số trong số điện thoại
        foreach (char digit in phoneNumber)
        {
            // Chuyển đổi chữ số thành số nguyên
            int number = int.Parse(digit.ToString());

            // Thêm chuỗi tương ứng vào kết quả
            result += numberText[number] + " ";
        }
        
        // Trả về kết quả, loại bỏ dấu cách ở cuối chuỗi
        return result.TrimEnd();
    }
}
