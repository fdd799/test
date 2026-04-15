<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavigateButton from './components/NavigateButton.vue'
</script>

<template>
    <nav>
        <NavigateButton path="/" text="Home"  />
        <NavigateButton path="/table" text="Table"  />
        <NavigateButton path="/users" text="Users"  />
    </nav>
    <RouterView />
</template>