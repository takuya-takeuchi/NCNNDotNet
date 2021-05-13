﻿using System;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace NcnnDotNet
{

    internal sealed partial class NativeMethods
    {

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ErrorType allocator_VkWeightAllocator_new(IntPtr vulkanDevice, out IntPtr returnValue);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void allocator_VkWeightAllocator_delete(IntPtr allocator);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void allocator_VkWeightAllocator_clear(IntPtr allocator);

    }

}