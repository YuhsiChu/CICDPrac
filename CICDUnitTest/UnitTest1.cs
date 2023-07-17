namespace CICDUnitTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void MyTestMethod()
    {
        // Arrange: 初始化測試所需的資源

        // Act: 執行要測試的操作

        // Assert: 驗證操作的結果是否符合預期

        // Example assertion:
        int result = Add(2, 3);
        Assert.AreEqual(5, result, "Addition result should be 5");
    }

    // Example method:
    public int Add(int a, int b)
    {
        return a + b;
    }
}
