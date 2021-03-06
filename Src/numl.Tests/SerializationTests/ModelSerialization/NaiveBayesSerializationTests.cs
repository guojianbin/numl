﻿using System;
using numl.Model;
using System.Linq;
using numl.Tests.Data;
using Xunit;
using numl.Supervised.NaiveBayes;
using System.Collections.Generic;

namespace numl.Tests.SerializationTests.ModelSerialization
{
    [Trait("Category", "Serialization")]
    public class NaiveBayesSerializationTests : BaseSerialization
    {
        [Fact]
        public void Tennis_Naive_Bayes_Save_And_Load_Test()
        {
            var data = Tennis.GetData();
            var description = Descriptor.Create<Tennis>();
            var generator = new NaiveBayesGenerator(2);
            var model = generator.Generate(description, data) as NaiveBayesModel;

            var file = GetPath();
            Register.Type<Tennis>();
            var lmodel = SaveAndLoad(model, file);

            Assert.Equal(model.Root, lmodel.Root);
        }

        [Fact]
        public void Tennis_Naive_Bayes_Save_And_Load_Test_Json()
        {
            var data = Tennis.GetData();
            var description = Descriptor.Create<Tennis>();
            var generator = new NaiveBayesGenerator(2);
            var model = generator.Generate(description, data) as NaiveBayesModel;

            var file = GetPath();
            Register.Type<Tennis>();
            var lmodel = SaveAndLoadJson(model);

            Assert.Equal(model.Root, lmodel.Root);
        }

        [Fact]
        public void Iris_Naive_Bayes_Save_And_Load_Test()
        {
            var data = Iris.Load();
            var description = Descriptor.Create<Iris>();
            var generator = new NaiveBayesGenerator(2);
            var model = generator.Generate(description, data) as NaiveBayesModel;

            var file = GetPath();
            Register.Type<Iris>();
            var lmodel = SaveAndLoad(model, file);

            Assert.Equal(model.Root, lmodel.Root);
        }

        [Fact]
        public void Iris_Naive_Bayes_Save_And_Load_Test_Json()
        {
            var data = Iris.Load();
            var description = Descriptor.Create<Iris>();
            var generator = new NaiveBayesGenerator(2);
            var model = generator.Generate(description, data) as NaiveBayesModel;

            var file = GetPath();
            Register.Type<Iris>();
            var lmodel = SaveAndLoadJson(model);

            Assert.Equal(model.Root, lmodel.Root);
        }
    }
}
