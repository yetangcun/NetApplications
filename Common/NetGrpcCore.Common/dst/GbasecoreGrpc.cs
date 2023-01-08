// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/gbasecore.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcBaseCore.Services {
  public static partial class GrpcBaseCoreService
  {
    static readonly string __ServiceName = "GrpcBaseCore.Services.GrpcBaseCoreService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcBaseCore.Services.GrpcBaseReq> __Marshaller_GrpcBaseCore_Services_GrpcBaseReq = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcBaseCore.Services.GrpcBaseReq.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcBaseCore.Services.GrpcBaseRes> __Marshaller_GrpcBaseCore_Services_GrpcBaseRes = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcBaseCore.Services.GrpcBaseRes.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes> __Method_GrpcGeneralCall = new grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GrpcGeneralCall",
        __Marshaller_GrpcBaseCore_Services_GrpcBaseReq,
        __Marshaller_GrpcBaseCore_Services_GrpcBaseRes);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::Google.Protobuf.WellKnownTypes.Empty> __Method_GrpcGeneralCallWithoutResponse = new grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GrpcGeneralCallWithoutResponse",
        __Marshaller_GrpcBaseCore_Services_GrpcBaseReq,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcBaseCore.Services.GrpcBaseRes> __Method_GrpcGeneralCallWithoutReqparam = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcBaseCore.Services.GrpcBaseRes>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GrpcGeneralCallWithoutReqparam",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_GrpcBaseCore_Services_GrpcBaseRes);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes> __Method_GrpcClientWayStream = new grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "GrpcClientWayStream",
        __Marshaller_GrpcBaseCore_Services_GrpcBaseReq,
        __Marshaller_GrpcBaseCore_Services_GrpcBaseRes);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes> __Method_GrpcServerWayStream = new grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GrpcServerWayStream",
        __Marshaller_GrpcBaseCore_Services_GrpcBaseReq,
        __Marshaller_GrpcBaseCore_Services_GrpcBaseRes);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes> __Method_GrpcTwoWayStream = new grpc::Method<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "GrpcTwoWayStream",
        __Marshaller_GrpcBaseCore_Services_GrpcBaseReq,
        __Marshaller_GrpcBaseCore_Services_GrpcBaseRes);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcBaseCore.Services.GbasecoreReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of GrpcBaseCoreService</summary>
    [grpc::BindServiceMethod(typeof(GrpcBaseCoreService), "BindService")]
    public abstract partial class GrpcBaseCoreServiceBase
    {
      /// <summary>
      /// 有入参有返回
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcGeneralCall(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// 有入参无返回
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> GrpcGeneralCallWithoutResponse(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// 无入参有返回
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcGeneralCallWithoutReqparam(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// 客户端流式rpc
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcClientWayStream(grpc::IAsyncStreamReader<global::GrpcBaseCore.Services.GrpcBaseReq> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// 服务端流式rpc
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GrpcServerWayStream(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::IServerStreamWriter<global::GrpcBaseCore.Services.GrpcBaseRes> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// 双向流式rpc
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GrpcTwoWayStream(grpc::IAsyncStreamReader<global::GrpcBaseCore.Services.GrpcBaseReq> requestStream, grpc::IServerStreamWriter<global::GrpcBaseCore.Services.GrpcBaseRes> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for GrpcBaseCoreService</summary>
    public partial class GrpcBaseCoreServiceClient : grpc::ClientBase<GrpcBaseCoreServiceClient>
    {
      /// <summary>Creates a new client for GrpcBaseCoreService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public GrpcBaseCoreServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for GrpcBaseCoreService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public GrpcBaseCoreServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected GrpcBaseCoreServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected GrpcBaseCoreServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// 有入参有返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcBaseCore.Services.GrpcBaseRes GrpcGeneralCall(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcGeneralCall(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 有入参有返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcBaseCore.Services.GrpcBaseRes GrpcGeneralCall(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GrpcGeneralCall, null, options, request);
      }
      /// <summary>
      /// 有入参有返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcGeneralCallAsync(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcGeneralCallAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 有入参有返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcGeneralCallAsync(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GrpcGeneralCall, null, options, request);
      }
      /// <summary>
      /// 有入参无返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty GrpcGeneralCallWithoutResponse(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcGeneralCallWithoutResponse(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 有入参无返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty GrpcGeneralCallWithoutResponse(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GrpcGeneralCallWithoutResponse, null, options, request);
      }
      /// <summary>
      /// 有入参无返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> GrpcGeneralCallWithoutResponseAsync(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcGeneralCallWithoutResponseAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 有入参无返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> GrpcGeneralCallWithoutResponseAsync(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GrpcGeneralCallWithoutResponse, null, options, request);
      }
      /// <summary>
      /// 无入参有返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcBaseCore.Services.GrpcBaseRes GrpcGeneralCallWithoutReqparam(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcGeneralCallWithoutReqparam(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 无入参有返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcBaseCore.Services.GrpcBaseRes GrpcGeneralCallWithoutReqparam(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GrpcGeneralCallWithoutReqparam, null, options, request);
      }
      /// <summary>
      /// 无入参有返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcGeneralCallWithoutReqparamAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcGeneralCallWithoutReqparamAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 无入参有返回
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcGeneralCallWithoutReqparamAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GrpcGeneralCallWithoutReqparam, null, options, request);
      }
      /// <summary>
      /// 客户端流式rpc
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncClientStreamingCall<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes> GrpcClientWayStream(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcClientWayStream(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 客户端流式rpc
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncClientStreamingCall<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes> GrpcClientWayStream(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_GrpcClientWayStream, null, options);
      }
      /// <summary>
      /// 服务端流式rpc
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcServerWayStream(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcServerWayStream(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 服务端流式rpc
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::GrpcBaseCore.Services.GrpcBaseRes> GrpcServerWayStream(global::GrpcBaseCore.Services.GrpcBaseReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GrpcServerWayStream, null, options, request);
      }
      /// <summary>
      /// 双向流式rpc
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncDuplexStreamingCall<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes> GrpcTwoWayStream(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GrpcTwoWayStream(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// 双向流式rpc
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncDuplexStreamingCall<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes> GrpcTwoWayStream(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_GrpcTwoWayStream, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override GrpcBaseCoreServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GrpcBaseCoreServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(GrpcBaseCoreServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GrpcGeneralCall, serviceImpl.GrpcGeneralCall)
          .AddMethod(__Method_GrpcGeneralCallWithoutResponse, serviceImpl.GrpcGeneralCallWithoutResponse)
          .AddMethod(__Method_GrpcGeneralCallWithoutReqparam, serviceImpl.GrpcGeneralCallWithoutReqparam)
          .AddMethod(__Method_GrpcClientWayStream, serviceImpl.GrpcClientWayStream)
          .AddMethod(__Method_GrpcServerWayStream, serviceImpl.GrpcServerWayStream)
          .AddMethod(__Method_GrpcTwoWayStream, serviceImpl.GrpcTwoWayStream).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GrpcBaseCoreServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GrpcGeneralCall, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes>(serviceImpl.GrpcGeneralCall));
      serviceBinder.AddMethod(__Method_GrpcGeneralCallWithoutResponse, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcBaseCore.Services.GrpcBaseReq, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.GrpcGeneralCallWithoutResponse));
      serviceBinder.AddMethod(__Method_GrpcGeneralCallWithoutReqparam, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::GrpcBaseCore.Services.GrpcBaseRes>(serviceImpl.GrpcGeneralCallWithoutReqparam));
      serviceBinder.AddMethod(__Method_GrpcClientWayStream, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes>(serviceImpl.GrpcClientWayStream));
      serviceBinder.AddMethod(__Method_GrpcServerWayStream, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes>(serviceImpl.GrpcServerWayStream));
      serviceBinder.AddMethod(__Method_GrpcTwoWayStream, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::GrpcBaseCore.Services.GrpcBaseReq, global::GrpcBaseCore.Services.GrpcBaseRes>(serviceImpl.GrpcTwoWayStream));
    }

  }
}
#endregion
