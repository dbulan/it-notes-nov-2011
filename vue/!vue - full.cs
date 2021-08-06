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
	
# Example
	
const app = Vue.createApp({
  data() {
    return {
      header: 'hello from vue'
    }
  }
}).mount('#app')

devtools -> app.header = 'hello from devtools';