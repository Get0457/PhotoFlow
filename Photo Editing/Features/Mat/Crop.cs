﻿using Newtonsoft.Json.Linq;
using System;
using OpenCvSharp;
using CvMat = OpenCvSharp.Mat;
namespace PhotoEditing.Features.Mat
{
    public class Crop : MatBasedFeature<CvMat>
    {
        IFeatureDataTypes<uint> X;
        IFeatureDataTypes<uint> Y;
        IFeatureDataTypes<uint> Width;
        IFeatureDataTypes<uint> Height;
        public override string FeatureName => $"{base.FeatureName}.Crop";

        public override bool IsAvaliable(IFeatureDataTypes<CvMat> Input) => Input.Value != null;

        public override bool HasDialog { get; } = true;
        public override ThemeContentDialog CallDialog { get; } = new ThemeContentDialog
        {
            
        };

        public override JObject SaveJSON()
            => new JObject(
                new JProperty("Feature", FeatureName),
                new JProperty("Parameters", new JObject(
                    new JProperty("X", X),
                    new JProperty("Y", Y),
                    new JProperty("Width", Width),
                    new JProperty("Height", Height)
                ))
            );
        public override void LoadFromJSON(JObject obj)
        {
            var token = obj["Parameters"];
            X = token["X"].ToObject<uint>();
            Y = token["Y"].ToObject<uint>();
            Width = token["Width"].ToObject<uint>();
            Height = token["Height"].ToObject<uint>();
        }
        public override IFeatureDataTypes<CvMat> Apply(IFeatureDataTypes<CvMat> Input)
        {
            return Input.Value.SubMat((int)Y.Value, (int)Y.Value + (int)Height.Value, (int)X.Value, (int)X.Value + (int)Width.Value);
        }
    }
}