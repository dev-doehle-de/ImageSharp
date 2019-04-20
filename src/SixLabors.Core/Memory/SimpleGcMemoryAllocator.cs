﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Buffers;
using SixLabors.Memory.Internals;

namespace SixLabors.Memory
{
    /// <summary>
    /// Implements <see cref="MemoryAllocator"/> by newing up arrays by the GC on every allocation requests.
    /// </summary>
    public sealed class SimpleGcMemoryAllocator : MemoryAllocator
    {
        /// <inheritdoc />
        public override IMemoryOwner<T> Allocate<T>(int length, AllocationOptions options = AllocationOptions.None)
        {
            Guard.MustBeGreaterThanOrEqualTo(length, 0, nameof(length));
            Guard.MustBeLessThan(length, int.MaxValue, nameof(length));

            return new BasicArrayBuffer<T>(new T[length]);
        }

        /// <inheritdoc />
        public override IManagedByteBuffer AllocateManagedByteBuffer(int length, AllocationOptions options = AllocationOptions.None)
        {
            Guard.MustBeGreaterThanOrEqualTo(length, 0, nameof(length));
            Guard.MustBeLessThan(length, int.MaxValue, nameof(length));

            return new BasicByteBuffer(new byte[length]);
        }
    }
}