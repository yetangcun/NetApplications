-- 首先是进到protoc.exe文件目录下
-- 通过protoc.exe把proto文件转换为.cs文件
.\protoc.exe --csharp_out=dst proto/transbase.proto