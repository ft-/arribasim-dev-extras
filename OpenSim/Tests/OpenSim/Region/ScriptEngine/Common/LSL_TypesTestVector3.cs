/*
 * Copyright (c) Contributors, http://opensimulator.org/
 * See CONTRIBUTORS.TXT for a full list of copyright holders.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the OpenSim Project nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.Collections.Generic;
using NUnit.Framework;
using OpenSim.Tests.Common;
using OpenSim.Region.ScriptEngine.Common;
using vector = OpenSim.Region.ScriptEngine.Common.LSL_Types.Vector3;

namespace OpenSim.Region.ScriptEngine.Common.Tests
{
    [TestFixture]
    public class LSL_TypesTestVector3
    {
        /// <summary>
        /// Tests for Vector3
        /// </summary>
        [Test]
        public void TestDotProduct()
        {
            // The numbers we test for.
            Dictionary<string, double> expectsSet = new Dictionary<string, double>();
            expectsSet.Add("<1, 2, 3> * <2, 3, 4>", 20.0);
            expectsSet.Add("<1, 2, 3> * <0, 0, 0>", 0.0);

            double result;
            string[] parts;
            string[] delim = { "*" };

            foreach (KeyValuePair<string, double> ex in expectsSet)
            {
                parts = ex.Key.Split(delim, System.StringSplitOptions.None);
                result = new vector(parts[0]) * new vector(parts[1]);
                Assert.AreEqual(ex.Value, result);
            }
        }

        [Test]
        public void TestUnaryMinusOperator()
        {
            Assert.AreEqual(new vector(-1, -1, -1), - (new vector(1, 1, 1)));
            Assert.AreEqual(new vector(0, 0, 0), - (new vector(0, 0, 0)));
        }
    }
}
