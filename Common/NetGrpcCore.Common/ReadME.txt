-- 首先是进到protoc.exe文件目录下
-- 通过protoc.exe把proto文件转换为.cs文件
powershell: .\protoc.exe --csharp_out=dst proto/gbasecore.proto --grpc_out=dst --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe
cmd: protoc.exe --csharp_out=dst proto/gbasecore.proto --grpc_out=dst --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe