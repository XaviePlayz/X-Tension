//-----------------------------------------------------------------------
// <copyright file="GvrBetaHeadset.cs" company="Google LLC">
// Copyright 2019 Google LLC. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

/// <summary>Daydream Beta API.</summary>
/// <remarks>
/// This API surface is for experimental purposes and may change or be removed in any future release
/// without forewarning.
/// </remarks>
namespace GoogleVR.Beta
{
    using System;
    using System.Runtime.InteropServices;
    using Gvr.Internal;
    using UnityEngine;

    /// <summary>
    /// The different supported appearances that determine how see-through camera
    /// frames will be drawn.
    /// </summary>
    /// <remarks>Matches the C API enum `gvr_beta_see_through_camera_mode`.</remarks>
    public enum GvrBetaSeeThroughCameraMode
    {
        /// <summary>The default behavior where no camera frames will be drawn.</summary>
        Disabled = 0,

        /// <summary>
        /// The monochrome image will be shown as a grayscale image.
        /// A theoretical color image will be shown in color.
        /// </summary>
        RawImage = 1,

        /// <summary>
        /// The monochrome image will be mapped to a blue to orange to white color
        /// gradient.
        /// </summary>
        ToneMap = 2,
    }

    /// <summary>
    /// The different scene types that an app can have. These control where the scene
    /// is rendered from. Generally in a virtual scene the scene should be rendered from
    /// the users' eyes while an augmented scene should be rendered from the camera's
    /// position to match the see-through images. More details can be found in the
    /// online developer documentation.
    /// </summary>
    public enum GvrBetaSeeThroughSceneType
    {
        /// <summary>Virtual scene type.</summary>
        /// <remarks>
        /// This represents a scene either composed entirely of virtual objects
        /// with no see-through or a scene that is primarily virtual with small
        /// cut outs for see-through. No head pose adjustments are applied with this
        /// scene type.
        /// </remarks>
        Virtual = 0,

        /// <summary>Augmented scene type with virtual objects.</summary>
        /// <remarks>
        /// This represents a scene that is primarily see-through with sparse virtual
        /// objects inside the real environment.  Head poses are adjusted based on camera
        /// geometry to make virtual objects track properly with the real environment.
        /// </remarks>
        Augmented = 1
    }

    /// <summary>Daydream headset beta API.</summary>
}
