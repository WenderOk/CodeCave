project(tests)

add_executable(${PROJECT_NAME} gtest.cpp)

set(CMAKE_CXX_STANDARD 11)

target_link_libraries(${PROJECT_NAME} PUBLIC
  lib
  gtest
  gtest_main
)