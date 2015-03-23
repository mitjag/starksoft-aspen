﻿/*
* Copyright (c) 2015 Benton Stark
* This file is part of the Starksoft Aspen library.
*
* Starksoft Aspen is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
* 
* Starksoft Aspen is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License
* along with Starksoft Aspen.  If not, see <http://www.gnu.org/licenses/>.
*   
*/

// disable visual studio comment on public function warnings
// for unit tests
#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;
using System.Diagnostics;
using System.Net.Sockets;
using Starksoft.Aspen.Proxy;

namespace Starksoft.Aspen.Tests
{
    /// <summary>
    /// Test fixture for Proxy classes.  A proxy server supporting SOCKS and HTTP must be running
    /// on the local host for the unit tests to work.  
    /// 
    /// proxy           listen
    /// protocol        port
    /// ========        ====
    /// SOCKSv4         1080
    /// SOCKSv4a        1080
    /// SOCKSv5         1080
    /// HTTP            8080
    /// 
    /// </summary>
    [TestFixture]
    public class TestProxyClient
    {
        [TestCase("localhost", 1080, "httpbin.org", 80)]
        public void TestSocks5CreateConnection(string proxyHost, int proxyPort, string destHost, int destPort)
        {

            Socks5ProxyClient p = new Socks5ProxyClient();
            p.ProxyHost = proxyHost;
            p.ProxyPort = proxyPort;
            TcpClient c = p.CreateConnection(destHost, destPort);

            byte[] sendBuf = System.Text.ASCIIEncoding.ASCII.GetBytes("GET / HTTP/1.1\n");
            c.GetStream().Write(sendBuf, 0, sendBuf.Length);
            byte[] recvBuf = new byte[1024];
            c.GetStream().Read(recvBuf, 0, recvBuf.Length);
            Console.Out.WriteLine(System.Text.ASCIIEncoding.ASCII.GetString(recvBuf));
            c.Close();
        }

        [TestCase("localhost", 8080, "httpbin.org", 80)]
        public void TestHttpCreateConnection(string proxyHost, int proxyPort, string destHost, int destPort)
        {

            HttpProxyClient p = new HttpProxyClient();
            p.ProxyHost = proxyHost;
            p.ProxyPort = proxyPort;
            TcpClient c = p.CreateConnection(destHost, destPort);

            byte[] sendBuf = System.Text.ASCIIEncoding.ASCII.GetBytes("GET / HTTP/1.1\n");
            c.GetStream().Write(sendBuf, 0, sendBuf.Length);
            byte[] recvBuf = new byte[1024];
            c.GetStream().Read(recvBuf, 0, recvBuf.Length);
            Console.Out.WriteLine(System.Text.ASCIIEncoding.ASCII.GetString(recvBuf));
            c.Close();
        }

        [TestCase("localhost", 1080, "httpbin.org", 80)]
        public void TestSocks4CreateConnection(string proxyHost, int proxyPort, string destHost, int destPort)
        {

            Socks4ProxyClient p = new Socks4ProxyClient();
            p.ProxyHost = proxyHost;
            p.ProxyPort = proxyPort;
            TcpClient c = p.CreateConnection(destHost, destPort);

            byte[] sendBuf = System.Text.ASCIIEncoding.ASCII.GetBytes("GET / HTTP/1.1\n");
            c.GetStream().Write(sendBuf, 0, sendBuf.Length);
            byte[] recvBuf = new byte[1024];
            c.GetStream().Read(recvBuf, 0, recvBuf.Length);
            Console.Out.WriteLine(System.Text.ASCIIEncoding.ASCII.GetString(recvBuf));
            c.Close();
        }

        [TestCase("localhost", 1080, "httpbin.org", 80)]
        public void TestSocks4aCreateConnection(string proxyHost, int proxyPort, string destHost, int destPort)
        {

            Socks4aProxyClient p = new Socks4aProxyClient();
            p.ProxyHost = proxyHost;
            p.ProxyPort = proxyPort;
            TcpClient c = p.CreateConnection(destHost, destPort);

            byte[] sendBuf = System.Text.ASCIIEncoding.ASCII.GetBytes("GET / HTTP/1.1\n");
            c.GetStream().Write(sendBuf, 0, sendBuf.Length);
            byte[] recvBuf = new byte[1024];
            c.GetStream().Read(recvBuf, 0, recvBuf.Length);
            Console.Out.WriteLine(System.Text.ASCIIEncoding.ASCII.GetString(recvBuf));
            c.Close();
        }

    }
}