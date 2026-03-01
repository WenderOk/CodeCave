cmake_minimum_required(VERSION 3.23)

project(HomeWork)

add_executable(Main)

target_sources(Main
  PRIVATE
    main.cpp
    lib.cpp
)

add_library(lib)

target_sources(lib
  PRIVATE
    lib.cpp
  PUBLIC
    FILE_SET HEADERS
    FILES
        lib.h
)