# -*- encoding: utf-8 -*-
# stub: simple_console 0.0.1 ruby lib

Gem::Specification.new do |s|
  s.name = "simple_console"
  s.version = "0.0.1"

  s.required_rubygems_version = Gem::Requirement.new(">= 0") if s.respond_to? :required_rubygems_version=
  s.require_paths = ["lib"]
  s.authors = ["Alexey Melezhik"]
  s.date = "2015-06-25"
  s.description = "A simple formatter for console output"
  s.email = "melezhik@gmail.com"
  s.files = ["lib/simple/console.rb"]
  s.homepage = "https://github.com/melezhik/simple_console"
  s.rubygems_version = "2.4.8"
  s.summary = "formatter for console output"

  if s.respond_to? :specification_version then
    s.specification_version = 4

    if Gem::Version.new(Gem::VERSION) >= Gem::Version.new('1.2.0') then
      s.add_runtime_dependency(%q<term-ansicolor>, [">= 0"])
      s.add_runtime_dependency(%q<logger>, [">= 0"])
    else
      s.add_dependency(%q<term-ansicolor>, [">= 0"])
      s.add_dependency(%q<logger>, [">= 0"])
    end
  else
    s.add_dependency(%q<term-ansicolor>, [">= 0"])
    s.add_dependency(%q<logger>, [">= 0"])
  end
end
