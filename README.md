
# Student management website & Online-quiz management 
## Trang web quản lý sinh viên và thi trắc nghiệm Online
- Được rebuild dựa trên đề tài thực tập, tuy còn nhiều lỗi nhưng tôi chắc chắn hài lòng về trang web này (´ ∀ ` *)
## ✨Trang web gồm có các chức năng ✨
- Quản lý sinh viên
- Quản lý môn học, bài thi
- Quản lý điểm thi
- Quản lý tài khoản, quyền truy cập
- Thi trắc nghiệm online
- Import danh sách sinh viên và danh sách câu hỏi-trả lời
## 🤷‍♀️ Những thay đổi trong tương lai 🤷‍♀️
- Nâng cấp bảo mật, phân quyền
- Tối ưu hóa tốc độ tải web
- Sửa bug
## 🎉 Những công nghệ đã sử dụng để build web 🎉
- Bootstrap - UI Boilerplate
- ASP.NET 5 - backend framework
- SQL Server - database
- Jquery
## 🐱‍🐉 Hướng dẫn cài đặt và sử dụng 🐱‍🐉
- Clone project về sử dụng cú pháp :
```
git clone https://github.com/thawsgnotwjbu3103/online-quiz-public.git
```
- Trong thư mục OnlineQuiz/AppData có chứa file backup của database => restore
- Mở file appsetting.json và sửa DefaultCon lại, ví dụ
```
  "ConnectionStrings": {
    "DefaultCon": "Server=THANG-PC;database=OnlineQuiz;Trusted_Connection=True;Integrated Security=True;MultipleActiveResultSets=True"
  }
```
Chú ý : Để không bị lỗi khi truy cập trang quyền và tài khoản, luôn thêm dòng "MultipleActiveResultSets=True"
- Chạy chương trình (❁´◡`❁)
- Tài khoản admin : admin - admin123@

#### 🎉🎉🎉🎉🎉 Created by Nông Đức Thắng - CNTT 44 - CĐSP Tây Ninh (^///^) 
#### 💋💋💋💋💋 Special thanks to Trường CĐSP Tây Ninh & Trung Tâm CNTT Tỉnh Tây Ninh ٩(◕‿◕｡)۶
