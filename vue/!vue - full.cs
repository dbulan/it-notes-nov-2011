# VUE - FULL

Vue is a progressive framework for building user interfaces.

There are four primary ways of adding Vue.js to a project:

1. Import it as a {CDN package} on the page
2. Download the JavaScript files and {host them yourself}
3. Install it using {npm}
4. Use the official {CLI} to scaffold a project, which provides batteries-included build setups for a modern frontend workflow (e.g., hot-reload, lint-on-save, and much more)
	$ https://cli.vuejs.org
	$ npm install -g @vue/cli 	// For Vue 3, you should use Vue CLI v4.5
	$ vue upgrade --next		// Vue upgrade --next
	
---
	
# Example
	
// devtool v1
const app = Vue.createApp({
  data() {
    return {
      header: 'hello from vue'
    }
  }
}).mount('#app')

// devtools -> app.header = 'hello from devtools';

-

// devtool v2
const app = Vue.createApp({
  data() {
    return { count: 4 }
  }
})
const vm = app.mount('#app')

// console.log(vm.$data.count) // => 4
// console.log(vm.count)       // => 4

---

# Lifecycle Hooks

/**
	Each component instance goes through a series of initialization steps when it's created.
	For example, it needs to set up data observation, compile the template, mount the instance to the DOM, and update the DOM when data changes. 
	Along the way, it also runs functions called lifecycle hooks, giving users the opportunity to add their own code at specific stages.

	(!) Tip
	Don't use arrow functions (opens new window)on an options property or callback, such as created: () => console.log(this.a) or vm.$watch('a', newValue => this.myMethod()). Since an arrow function doesn't have a {this}.
*/


---

# Interpolations

// one-time interpolation
<span v-once>This will never change: {{ msg }}</span>

# Dynamic Arguments

<a v-bind:[attributeName]="url"> ... </a> // attributeName will be dynamically evaluated as a JavaScript expression
<a v-on:[eventName]="doSomething"> ... </a>

---

# Conditional Rendering

// v-if & v-show
The difference is that an element with {v-show} will always be rendered and remain in the DOM;  {v-show} only toggles the display CSS property of the element.
(!) {v-show} doesn't support the <template> element, nor does it work with {v-else}

/**
	{v-if} is "real" conditional rendering because it ensures that event listeners and child components inside the conditional block are properly [destroyed] and [re-created] during toggles.
	{v-if} is also lazy: if the condition is false on initial render, it will not do anything - the conditional block won't be rendered until the condition becomes true for the first time.
	
	In comparison, {v-show} is much simpler - the element is always rendered regardless of initial condition, with CSS-based toggling.
	Generally speaking, {v-if} has higher toggle costs while v-show has higher initial render costs. 
	So prefer {v-show} if you need to toggle something [very often], and prefer {v-if} if the condition is unlikely [to change at runtime].
	
	{v-if} with {v-for}
	Using {v-if} and {v-for} together is not recommended. See the style guide for further information.
	BAD:  v-for="user in users" v-if="user.isActive"
	GOOD: v-for="user in activeUsers"
*/

---

# List Rendering

// You can also use {v-for} to iterate through the properties of an object.

myObject: {
  title: 'How to do lists in Vue',
  author: 'Jane Doe',
  publishedAt: '2016-04-10'
}

<li v-for="(value, name, index) in myObject">
  {{ index }}. {{ name }}: {{ value }}
</li>

0. title: How to do lists in Vue
1. author: Jane Doe
2. publishedAt: 2020-03-22

/**
	When they exist on the same node, {v-if} has a higher priority than {v-for}. 
	That means the {v-if} condition will not have access to variables from the scope of the {v-for}:
*/

// This will throw an error because property "todo" is not defined on instance.
<li v-for="todo in todos" v-if="!todo.isComplete">

// This can be fixed by moving {v-for} to a wrapping <template> tag:
<template v-for="todo in todos" :key="todo.name">
	<li v-if="!todo.isComplete">{{ todo.name }}</li>
</template>

---

# Array Change Detection

Vue wraps an observed array's mutation methods so they will also trigger view updates. 
The wrapped methods are: push() pop() shift() unshift() splice() sort() reverse().
(!) there are also non-mutating methods, e.g. filter(), concat() and slice(), which do not mutate the original array but always return a new array.

# v-for with a Range
<span v-for="n in 10" :key="n">{{ n }} </span> // 12345678910

# v-for with a Component
<my-component v-for="item in items" :key="item.id"></my-component>

/**
However, this won't automatically pass any data to the component, because components have isolated scopes of their own. 
In order to pass the iterated data into the component, we should also use props:
*/
<my-component v-for="(item, index) in items" :item="item" :index="index" :key="item.id"></my-component>