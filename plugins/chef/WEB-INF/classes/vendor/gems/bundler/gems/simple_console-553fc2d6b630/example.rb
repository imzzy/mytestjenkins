#!/usr/bin/env ruby

require "rubygems"
require 'lib/simple/console.rb'


puts Simple::Console.new(:color_output => true).info("hello world")
puts Simple::Console.new(:color_output => true).info("hello world",:title => 'I say')
puts Simple::Console.new(:color_output => true).error("bad thing happen")
