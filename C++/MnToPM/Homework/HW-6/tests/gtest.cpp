#include <gtest/gtest.h>
#include "../modules/lib.h"

TEST(libTest, TestEqual)
{
    EXPECT_EQ(sum(2,3), 5);
}

TEST(libTest, TestOutputNumbers) 
{
    EXPECT_EQ(10, outputNumbers(10));
}
 
TEST(libTest, TestZero)
{
    EXPECT_EQ(1, fact(0));
}

TEST(libTest, TestOne)
{
    EXPECT_EQ(1, fact(1));
}

TEST(libTest, TestNeg)
{
    EXPECT_EQ(-1, fact(-5));
}

TEST(libTest, TestAnother)
{
    EXPECT_EQ(120, fact(5));
}