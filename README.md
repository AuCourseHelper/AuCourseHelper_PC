# AuCourseHelper
 - 真理大學資訊工程系-課堂輔助系統
 - Created by： Microsoft Visual Studio 2013
 - Language： Microsoft Visual Basic 2013

[程式規劃](#程式規劃)、[系統功能](#系統功能)、[系統流程](#系統流程)、[資料庫結構](#資料庫結構)
---


## 程式規劃
 - 系統區分為四隻子程式，[伺服端](#伺服端)、[教師端](#教師端)、[學生端](#學生端)、[自動更新程式](#自動更新程式)


## 系統功能
### 伺服端
 - 介接Database
   1. SQL查詢，同步處理，回傳DataTable
   2. SQL命令，排程處理，回傳狀態
 - 紀錄連接使用者詳細資料與動作
 - 檢視Log記錄檔
 - 剔除指定Client連線

### 教師端
 - 登入/不開放註冊/修改密碼
 - 選擇所屬課堂
   - 初次建立
     1. 鍵入/匯入學生資訊
     2. 排座位 [非必要]
   - 授課
     1. 點名 (表格式、座位式) [選項:公開]
     2. 評分 (表格式、座位式) [選項:公開]
     3. 作業建立 (文字、PDF)
        - 檔案上傳 [選項:時限、覆寫]
        - 程式上傳 [選項:時限、覆寫、編譯、測資]
     4. 考試建立
        - 程式上傳 [選項:時限、覆寫、編譯、測資]
          - 一般式
          - 小組式 (限定繳交人員，如組長)
     5. 統計報表 (顯示、匯出Excel、列印)
        - 出席狀況
        - 成績統計
        - 上傳狀況

### 學生端
 - 登入/註冊/修改密碼
 - 選擇所屬課堂
   - 上課
     1. 檢視到課名單 (表格式、座位式)
     2. 作業繳交
        - 檔案上傳 (期限內)
        - 歷史作業討論 (期限外)
     3. 考試上傳
        - 編譯測試
        - 正式上傳
     4. 統計報表 (顯示、匯出Excel、列印)
        - 個人出席狀況 (如果有公開)
        - 個人成績狀況 (如果有公開)
        - 個人上傳狀況

### 自動更新程式
 - 檢查是否有更新檔
 - 自動下載更新


## 系統流程
 - *未完成*


## 資料庫結構
 - Course (課程清單)
   1. Id/識別碼 = int [自動編號]
   2. ChooseNum/選課代號 = nchar(5)
   3. Class/開課班級 = nchar(10)
   4. Term/學期別 = nchar(5)
   5. Name/課程名稱 = nchar(20)
   6. Credit/學分 = int
   7. Time/上課時間 = nchar(15)
   8. Classroom/上課教室 = nchar(10)
   9. Teacher/授課教師 = nchar(10)
   10. CourseScoreId/評分計數 = int
   11. CourseFileId/作業考試計數 = int

 - Teacher (教師清單)
   1. Id/識別碼 = int [自動編號]
   2. Num/教師編號 = nchar(5)
   3. Name/姓名 = nchar(10)
   4. Pwd/密碼 = nchar(20)
   5. LastLogin/最後登入時間 = nchar(13)
   6. LastIp/最後登入IP = nchar(15)
   7. WebSite/個人網頁 = ntext
   8. OfficeTime/辦公室時間 = nchar(20)

 - Student (學生清單)
   1. Id/識別碼 = int [自動編號]
   2. Num/學號 = nchar(8)
   3. Name/姓名 = nchar(10)
   4. Class/班級 = nchar(1)
   5. Pwd/密碼 = nchar(20)
   6. LastLogin/最後登入時間 = nchar(13)
   7. LastIp/最後登入IP = nchar(15)

 - CourseStudent (修課名單)
   1. Id/識別碼 = int [自動編號]
   2. CourseId/課程識別碼 = int
   3. StudentNum/學生學號 = nchar(8)

 - Attend (出席狀況 - 一位學生每次上課一筆)
   1. Id/識別碼 = bigint [自動編號]
   2. CourseId/課程識別碼 = int
   3. StudentId/學生識別碼 = int
   4. Status/狀況 = nchar(1)
   5. Date/出席日期 = nchar(8)

 - Score (成績狀況 - 一位學生每次評分一筆)
   1. Id/識別碼 = bigint [自動編號]
   2. CourseId/課程識別碼 = int
   3. CourseScoreId/課程成績計數碼 = int
   4. StudentId/學生識別碼 = int
   5. Score/成績 = float
   6. Date/評分日期 = nchar(8)

 - File (作業/考試上傳狀況 - *一位老師開一次作業一筆/一位學生上傳一次作業一筆*)
   1. Id/識別碼 = bigint [自動編號]
   2. CourseId/課程識別碼 = int
   3. UserId/人物識別碼 = int
   4. UserType/人物型態 = nchar(1)
   5. StartTime/開始日 = nchar(13)
   6. StopTime/結束日 = nchar(13)
   7. UploadTime/上傳日期 = nchar(13)
   8. FileName/檔案名稱 = nchar(13)
