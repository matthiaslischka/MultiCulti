using System.Globalization;
using FluentAssertions;

namespace MultiCulti.Tests;

public class UsingTests
{
    [Fact]
    public void ThreadCultureChange_ShouldBeRolledBack_AfterExceptionInUsingBlock()
    {
        var originalCultureInfo = new CultureInfo("en");
        Thread.CurrentThread.CurrentCulture = originalCultureInfo;
        Thread.CurrentThread.CurrentUICulture = originalCultureInfo;

        var atCultureInfo = new CultureInfo("at");

        try
        {
            using (atCultureInfo.AsCurrent())
            {
                Thread.CurrentThread.CurrentCulture.Name.Should().Be("at");
                Thread.CurrentThread.CurrentUICulture.Name.Should().Be("at");
                throw new Exception();
            }
        }
        catch
        {
            // ignored
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture.Name.Should().Be("en");
            Thread.CurrentThread.CurrentUICulture.Name.Should().Be("en");
        }
    }

    [Fact]
    public void ThreadCultureChange_WithinThreadCultureChange_ShouldBeRolledBack_AfterUsingBlocks()
    {
        var originalCultureInfo = new CultureInfo("en");
        Thread.CurrentThread.CurrentCulture = originalCultureInfo;
        Thread.CurrentThread.CurrentUICulture = originalCultureInfo;

        var deCultureInfo = new CultureInfo("de");
        var atCultureInfo = new CultureInfo("at");


        using (deCultureInfo.AsCurrent())
        {
            Thread.CurrentThread.CurrentCulture.Name.Should().Be("de");
            Thread.CurrentThread.CurrentUICulture.Name.Should().Be("de");

            using (atCultureInfo.AsCurrent())
            {
                Thread.CurrentThread.CurrentCulture.Name.Should().Be("at");
                Thread.CurrentThread.CurrentUICulture.Name.Should().Be("at");
            }

            Thread.CurrentThread.CurrentCulture.Name.Should().Be("de");
            Thread.CurrentThread.CurrentUICulture.Name.Should().Be("de");
        }

        Thread.CurrentThread.CurrentCulture.Name.Should().Be("en");
        Thread.CurrentThread.CurrentUICulture.Name.Should().Be("en");
    }
}