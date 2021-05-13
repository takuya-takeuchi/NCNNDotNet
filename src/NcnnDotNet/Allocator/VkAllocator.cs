﻿using System;

// ReSharper disable once CheckNamespace
namespace NcnnDotNet
{

    public abstract class VkAllocator : NcnnObject
    {

        #region Constructors

        protected VkAllocator()
        {
        }

        internal VkAllocator(IntPtr ptr, bool isEnabledDispose = true) :
            base(isEnabledDispose)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(ptr));

            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public bool Coherent
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.allocator_VkAllocator_get_coherent(this.NativePtr);
                return ret;
            }
        }

        public bool Mappable
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.allocator_VkAllocator_get_mappable(this.NativePtr);
                return ret;
            }
        }

        public uint BufferMemoryTypeIndex
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.allocator_VkAllocator_get_buffer_memory_type_index(this.NativePtr);
                return ret;
            }
        }

        public uint ImageMemoryTypeIndex
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.allocator_VkAllocator_get_image_memory_type_index(this.NativePtr);
                return ret;
            }
        }

        public VulkanDevice VkDev
        {
            get
            {
                this.ThrowIfDisposed();
                var ret = NativeMethods.allocator_VkAllocator_get_vkdev(this.NativePtr);
                return new VulkanDevice(ret, false);
            }
        }

        #endregion

        #region Methods

        public abstract void Clear();

        internal static VkAllocator GetAllocator(IntPtr allocator, NativeMethods.VkAllocatorType type, bool isEnabledDispose = true)
        {
            switch (type)
            {
                case NativeMethods.VkAllocatorType.VkBlobAllocator:
                    return new VkBlobAllocator(allocator, isEnabledDispose);
                case NativeMethods.VkAllocatorType.VkWeightAllocator:
                    return new VkWeightAllocator(allocator, isEnabledDispose);
                case NativeMethods.VkAllocatorType.VkStagingAllocator:
                    return new VkStagingAllocator(allocator, isEnabledDispose);
                case NativeMethods.VkAllocatorType.VkWeightStagingAllocator:
                    return new VkWeightStagingAllocator(allocator, isEnabledDispose);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        #endregion

    }

}